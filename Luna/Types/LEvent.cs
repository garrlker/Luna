﻿using System;
using System.IO;
using Luna.Assets;

namespace Luna.Types {
    public enum ActionType {
        Normal,
        Begin,
        End,
        Else,
        Exit,
        Repeat,
        Variable,
        Code
    }

    public enum ActionExecution {
        None,
        Function,
        Code
    }

    enum Events {
        Create,
        Destroy,
        Alarm,
        Step,
        Collision,
        Keyboard,
        Mouse,
        Other,
        Draw,
        KeyPress,
        KeyRelease,
        Trigger,//does this exist in 2.3? triggers were removed, were they not?
        CleanUp,
        PreCreate
    }

    class LEvent {
        public LObject Owner;
        public Int32 Subtype;
        public Int32 LibraryID;
        public Int32 ID;
        public ActionType Type;
        public bool UseRelative;
        public bool IsQuestion;
        public bool ApplyTo;
        public ActionExecution Execution;
        public string Name;
        public LCode Code;
        public Int32 ArgumentCount;
        public Int32 Caller;
        public bool IsRelative;
        public bool IsNot;

        public LEvent(LObject _object, Game _assets, BinaryReader _reader, LObject _owner, Int32 _type) {
            this.Owner = _owner;
            this.Subtype = _type;
            this.LibraryID = _reader.ReadInt32();
            this.ID = _reader.ReadInt32();
            this.Type = (ActionType)_reader.ReadInt32();
            this.UseRelative = _reader.ReadLBoolean();
            this.IsQuestion = _reader.ReadLBoolean();
            this.ApplyTo = _reader.ReadLBoolean();
            this.Execution = (ActionExecution)_reader.ReadInt32();
            this.Name = _assets.GetString(_reader.ReadInt32());
            this.Code = _assets.CodeMapping[_reader.ReadInt32()];
            this.ArgumentCount = _reader.ReadInt32();
            this.Caller = _reader.ReadInt32();
            this.IsRelative = _reader.ReadLBoolean();
            this.IsNot = _reader.ReadLBoolean();

            switch (this.Code.Name.Replace("gml_Object_" + _object.Name + "_", "")) {
                case "PreCreate_0": _object.PreCreate = this.Code; break;
                case "Create_0": _object.Create = this.Code; break;
                case "Step_1": _object.BeginStep = this.Code; break;
                case "Step_0": _object.Step = this.Code; break;
                case "Step_2": _object.EndStep = this.Code; break;
                case "Draw_0": _object.Draw = this.Code; break;
                case "Destroy_0": _object.Destroy = this.Code; break;
                case "CleanUp_0": _object.CleanUp = this.Code; break;
            }
        }
    }
}
