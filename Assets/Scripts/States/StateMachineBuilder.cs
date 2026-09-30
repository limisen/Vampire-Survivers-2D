using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class StateMachineBuilder
{
    readonly State root;

    public StateMachineBuilder(State root)
    {
        this.root = root;
    }

    public StateMachine Build()
    {
        var machine = new StateMachine(root);
        Wire(root, machine, new HashSet<State>());
        return machine;
    }

    // Constructs a VALID StateMachine by recursivly "Wiring up" each State 
    void Wire(State state, StateMachine machine, HashSet<State> visited)
    {
        if (state == null) return; // IF no state then skip
        if (!visited.Add(state)) return; // IF we've already visited then dont try to wire up a state we've already visited

        var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy; // Gets all the fields of the state
        var machineField = typeof(State).GetField("Machine", flags); // Specifically target the "Machine" field
        if (machineField != null) machineField.SetValue(state, machine); // IF it's empty (null) insert this StateMachine (this is done so all the states under a specific root share the same StateMachine)

        // "Walks" all the fields of this states *actual* type
        foreach (var fld in state.GetType().GetFields(flags))
        {
            if (!typeof(State).IsAssignableFrom(fld.FieldType)) continue; // Only consider fields that are State (Or subclasses of State)
            if (fld.Name == "parent") continue; // Skip the back reference to the state's parent, in order to avoid infinately calling this function.

            var child = (State)fld.GetValue(state);
            if (child == null) continue;
            if (!ReferenceEquals(child.Parent, state)) continue; // Ensure that this child is our direct child

            // Finally recurse into the child and "wire it up"
            Wire(child, machine, visited);
        }
    }
}
