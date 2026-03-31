using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.BuiltinInterfaces
{
    public class TimeMsg : Message
    {
        public const string k_Ros1MessageName = "std_msgs/Time";
        public const string k_Ros2MessageName = "builtin_interfaces/Time";

        // public override string RosMessageName => k_RosMessageName;

        // ROS1 seconds component
        public uint u_sec;
        //  This message communicates ROS Time defined here:
        //  https://design.ros2.org/articles/clock_and_time.html
        //  The seconds component, valid over all int32 values.
        public int sec;
        //  The nanoseconds component, valid in the range [0, 10e9).
        public uint nanosec;

        public TimeMsg()
        {
            this.sec = 0;
            this.nanosec = 0;
        }

        public TimeMsg(uint sec, uint nanosec)
        {
            this.u_sec = sec;
            this.nanosec = nanosec;
        }

        public TimeMsg(int sec, uint nanosec)
        {
            this.sec = sec;
            this.nanosec = nanosec;
        }

        public static TimeMsg Deserialize(MessageDeserializer deserializer) => new TimeMsg(deserializer);

        TimeMsg(MessageDeserializer deserializer)
        {
            if (deserializer.rosVersion != 2)
            {
                deserializer.Read(out this.u_sec);
            }
            else
            {
                deserializer.Read(out this.sec);
            }
            deserializer.Read(out this.nanosec);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            if (serializer.rosVersion != 2)
            {
                serializer.Write(this.u_sec);
            }
            else
            {
                serializer.Write(this.sec);
            }
            serializer.Write(this.nanosec);
        }

        public override string ToString()
        {
            return "Time: " +
            "\nsec (ROS1): " + u_sec.ToString() +
            "\nsec (ROS2): " + sec.ToString() +
            "\nnanosec: " + nanosec.ToString();
        }

#if UNITY_EDITOR
        [UnityEditor.InitializeOnLoadMethod]
#else
        [UnityEngine.RuntimeInitializeOnLoadMethod]
#endif
        public static void Register()
        {
            MessageRegistry.Register(k_Ros1MessageName, Deserialize);
            MessageRegistry.Register(k_Ros2MessageName, Deserialize);
        }
    }
}
