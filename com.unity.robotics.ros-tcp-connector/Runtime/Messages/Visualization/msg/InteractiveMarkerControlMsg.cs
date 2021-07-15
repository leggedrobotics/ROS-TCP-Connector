//Do not edit! This file was generated by Unity-ROS MessageGeneration.
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Unity.Robotics.ROSTCPConnector.MessageGeneration;

namespace RosMessageTypes.Visualization
{
    [Serializable]
    public class InteractiveMarkerControlMsg : Message
    {
        public const string k_RosMessageName = "visualization_msgs/InteractiveMarkerControl";
        public override string RosMessageName => k_RosMessageName;

        //  Represents a control that is to be displayed together with an interactive marker
        //  Identifying string for this control.
        //  You need to assign a unique value to this to receive feedback from the GUI
        //  on what actions the user performs on this control (e.g. a button click).
        public string name;
        //  Defines the local coordinate frame (relative to the pose of the parent
        //  interactive marker) in which is being rotated and translated.
        //  Default: Identity
        public Geometry.QuaternionMsg orientation;
        //  Orientation mode: controls how orientation changes.
        //  INHERIT: Follow orientation of interactive marker
        //  FIXED: Keep orientation fixed at initial state
        //  VIEW_FACING: Align y-z plane with screen (x: forward, y:left, z:up).
        public const byte INHERIT = 0;
        public const byte FIXED = 1;
        public const byte VIEW_FACING = 2;
        public byte orientation_mode;
        //  Interaction mode for this control
        // 
        //  NONE: This control is only meant for visualization; no context menu.
        //  MENU: Like NONE, but right-click menu is active.
        //  BUTTON: Element can be left-clicked.
        //  MOVE_AXIS: Translate along local x-axis.
        //  MOVE_PLANE: Translate in local y-z plane.
        //  ROTATE_AXIS: Rotate around local x-axis.
        //  MOVE_ROTATE: Combines MOVE_PLANE and ROTATE_AXIS.
        public const byte NONE = 0;
        public const byte MENU = 1;
        public const byte BUTTON = 2;
        public const byte MOVE_AXIS = 3;
        public const byte MOVE_PLANE = 4;
        public const byte ROTATE_AXIS = 5;
        public const byte MOVE_ROTATE = 6;
        //  "3D" interaction modes work with the mouse+SHIFT+CTRL or with 3D cursors.
        //  MOVE_3D: Translate freely in 3D space.
        //  ROTATE_3D: Rotate freely in 3D space about the origin of parent frame.
        //  MOVE_ROTATE_3D: Full 6-DOF freedom of translation and rotation about the cursor origin.
        public const byte MOVE_3D = 7;
        public const byte ROTATE_3D = 8;
        public const byte MOVE_ROTATE_3D = 9;
        public byte interaction_mode;
        //  If true, the contained markers will also be visible
        //  when the gui is not in interactive mode.
        public bool always_visible;
        //  Markers to be displayed as custom visual representation.
        //  Leave this empty to use the default control handles.
        // 
        //  Note:
        //  - The markers can be defined in an arbitrary coordinate frame,
        //    but will be transformed into the local frame of the interactive marker.
        //  - If the header of a marker is empty, its pose will be interpreted as
        //    relative to the pose of the parent interactive marker.
        public MarkerMsg[] markers;
        //  In VIEW_FACING mode, set this to true if you don't want the markers
        //  to be aligned with the camera view point. The markers will show up
        //  as in INHERIT mode.
        public bool independent_marker_orientation;
        //  Short description (< 40 characters) of what this control does,
        //  e.g. "Move the robot".
        //  Default: A generic description based on the interaction mode
        public string description;

        public InteractiveMarkerControlMsg()
        {
            this.name = "";
            this.orientation = new Geometry.QuaternionMsg();
            this.orientation_mode = 0;
            this.interaction_mode = 0;
            this.always_visible = false;
            this.markers = new MarkerMsg[0];
            this.independent_marker_orientation = false;
            this.description = "";
        }

        public InteractiveMarkerControlMsg(string name, Geometry.QuaternionMsg orientation, byte orientation_mode, byte interaction_mode, bool always_visible, MarkerMsg[] markers, bool independent_marker_orientation, string description)
        {
            this.name = name;
            this.orientation = orientation;
            this.orientation_mode = orientation_mode;
            this.interaction_mode = interaction_mode;
            this.always_visible = always_visible;
            this.markers = markers;
            this.independent_marker_orientation = independent_marker_orientation;
            this.description = description;
        }

        public static InteractiveMarkerControlMsg Deserialize(MessageDeserializer deserializer) => new InteractiveMarkerControlMsg(deserializer);

        private InteractiveMarkerControlMsg(MessageDeserializer deserializer)
        {
            deserializer.Read(out this.name);
            this.orientation = Geometry.QuaternionMsg.Deserialize(deserializer);
            deserializer.Read(out this.orientation_mode);
            deserializer.Read(out this.interaction_mode);
            deserializer.Read(out this.always_visible);
            deserializer.Read(out this.markers, MarkerMsg.Deserialize, deserializer.ReadLength());
            deserializer.Read(out this.independent_marker_orientation);
            deserializer.Read(out this.description);
        }

        public override void SerializeTo(MessageSerializer serializer)
        {
            serializer.Write(this.name);
            serializer.Write(this.orientation);
            serializer.Write(this.orientation_mode);
            serializer.Write(this.interaction_mode);
            serializer.Write(this.always_visible);
            serializer.WriteLength(this.markers);
            serializer.Write(this.markers);
            serializer.Write(this.independent_marker_orientation);
            serializer.Write(this.description);
        }

        public override string ToString()
        {
            return "InteractiveMarkerControlMsg: " +
            "\nname: " + name.ToString() +
            "\norientation: " + orientation.ToString() +
            "\norientation_mode: " + orientation_mode.ToString() +
            "\ninteraction_mode: " + interaction_mode.ToString() +
            "\nalways_visible: " + always_visible.ToString() +
            "\nmarkers: " + System.String.Join(", ", markers.ToList()) +
            "\nindependent_marker_orientation: " + independent_marker_orientation.ToString() +
            "\ndescription: " + description.ToString();
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
