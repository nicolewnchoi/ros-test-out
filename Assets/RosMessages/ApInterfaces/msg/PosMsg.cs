//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.ApInterfaces
{
    [Serializable]
    public class PosMsg : Message
    {
        public const string k_RosMessageName = "ap_interfaces/Pos";
        public override string RosMessageName => k_RosMessageName;

        public sbyte total;
        public ulong timestamp;
        public ulong id;
        public double[] x;
        public double[] y;
        public sbyte[] player_id;
        public string[] tag_id;
        public double[] size;
        public double ms;

        public PosMsg()
        {
            this.total = 0;
            this.timestamp = 0;
            this.id = 0;
            this.x = new double[32];
            this.y = new double[32];
            this.player_id = new sbyte[32];
            this.tag_id = new string[32];
            this.size = new double[32];
            this.ms = 0.0;
        }

        public PosMsg(sbyte total, ulong timestamp, ulong id, double[] x, double[] y, sbyte[] player_id, string[] tag_id, double[] size, double ms)
        {
            this.total = total;
            this.timestamp = timestamp;
            this.id = id;
            this.x = x;
            this.y = y;
            this.player_id = player_id;
            this.tag_id = tag_id;
            this.size = size;
            this.ms = ms;
        }

        public static PosMsg Deserialize(MessageDeserializer deserializer) => new PosMsg(deserializer);

        private PosMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.total);
            deserializer.Read(out this.timestamp);
            deserializer.Read(out this.id);
            deserializer.Read(out this.x, sizeof(double), 32);
            deserializer.Read(out this.y, sizeof(double), 32);
            deserializer.Read(out this.player_id, sizeof(sbyte), 32);
            deserializer.Read(out this.tag_id, 32);
            deserializer.Read(out this.size, sizeof(double), 32);
            deserializer.Read(out this.ms);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.total);
            serializer.Write(this.timestamp);
            serializer.Write(this.id);
            serializer.Write(this.x);
            serializer.Write(this.y);
            serializer.Write(this.player_id);
            serializer.Write(this.tag_id);
            serializer.Write(this.size);
            serializer.Write(this.ms);
        }

        public override string ToString()
        {
            return "PosMsg: " +
            "\ntotal: " + total.ToString() +
            "\ntimestamp: " + timestamp.ToString() +
            "\nid: " + id.ToString() +
            "\nx: " + System.String.Join(", ", x.ToList()) +
            "\ny: " + System.String.Join(", ", y.ToList()) +
            "\nplayer_id: " + System.String.Join(", ", player_id.ToList()) +
            "\ntag_id: " + System.String.Join(", ", tag_id.ToList()) +
            "\nsize: " + System.String.Join(", ", size.ToList()) +
            "\nms: " + ms.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_RosMessageName, Deserialize);
        }
    }
}
