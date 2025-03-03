using Unity.Collections;
using Unity.Networking.Transport;
using UnityEngine;
using System.Net.Sockets;
using System.IO;

public class NetWelcome : NetMessage
{
    public int AssignedTeam; //{ set; get; }
    public NetWelcome()
    {
        Code = OpCode.WELCOME;

    }
    public NetWelcome(DataStreamReader reader)
    {
        Code = OpCode.WELCOME;
        Deserialize(reader);
    }

    public override void Serialize(ref DataStreamWriter writer)
    {
        writer.WriteByte((byte)Code);
        writer.WriteInt(AssignedTeam);

    }


    public override void Deserialize(DataStreamReader reader)
    {
        //We already read the byte in the NetUtility::Ondata
        AssignedTeam = reader.ReadInt();

    }

    public override void ReceivedOnClient()
    {
        NetUtility.C_WELCOME?.Invoke(this);

    }
    public override void ReceivedOnServer(NetworkConnection con)
    {
        NetUtility.S_WELCOME?.Invoke(this, con);
    }
}
