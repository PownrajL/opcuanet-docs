// DOC
var machineNode = new OpcFolderNode("Machine");
var machineIsRunningNode = new OpcDataVariableNode<bool>(machineNode, "IsRunning");
 
// Note: An enumerable of nodes can be also passed.
var server = new OpcServer("opc.tcp://localhost:4840/", machineNode);

// DOC
public class MyNodeManager : OpcNodeManager
{
    public MyNodeManager()
        : base("http://mynamespace/")
    {
    }
}

// DOC
protected override IEnumerable<IOpcNode> CreateNodes(OpcNodeReferenceCollection references)
{
    // Define custom root node.
    var machineNode = new OpcFolderNode(new OpcName("Machine", this.DefaultNamespaceIndex));
 
    // Add custom root node to the Objects-Folder (the root of all server nodes):
    references.Add(machineNode, OpcObjectTypes.ObjectsFolder);
 
    // Add custom sub node beneath of the custom root node:
    var isMachineRunningNode = new OpcDataVariableNode<bool>(machineNode, "IsRunning");
 
    // Return each custom root node using yield return.
    yield return machineNode;
}

// DOC
// Note: An enumerable of node managers can be also passed.
var server = new OpcServer("opc.tcp://localhost:4840/", new MyNodeManager());