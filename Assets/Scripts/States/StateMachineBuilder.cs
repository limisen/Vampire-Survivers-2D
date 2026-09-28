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
        var m = new StateMachine(root);
        Wire(root, m, new HashSet<State>());
        return m;
    }

    // Constructs a VALID StateMachine by recursivly "Wiring up" each State 
    void Wire(State s, StateMachine m, HashSet<State> visited)
    {
        if (s == null) return; // IF no state then skip
        if (!visited.Add(s)) return; // IF we've already visited then dont try to wire up a state we've already visited

        var flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.FlattenHierarchy;
        var machineField = typeof(State).GetField("Machine", flags);
        if (machineField != null) machineField.SetValue(s, m);

        // "Walks" all the fields of this states *actual* type
        foreach (var fld in s.GetType().GetFields(flags))
        {
            if (!typeof(State).IsAssignableFrom(fld.FieldType)) continue; // Only consider fields that are State (Or subclasses of State)
            if (fld.Name == "parent") continue; // Skip the back reference to the state's parent, in order to avoid infinately calling this function.

            var child = (State)fld.GetValue(s);
            if (child == null) continue;
            if (!ReferenceEquals(child.Parent, s)) continue; // Ensure that this child is our direct child

            // Finally recurse into the child and "wire it up"
            Wire(child, m, visited);
        }
    }
}
