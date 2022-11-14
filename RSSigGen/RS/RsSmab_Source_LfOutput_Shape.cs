using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    //
    // Сводка:
    //     RsSmab_Source_LfOutput_Shape commands group definition
    //     Sub-classes count: 3
    //     Commands count: 1
    //     Total commands count: 10
    public class RsSmab_Source_LfOutput_Shape
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_Source_LfOutput_Shape_Pulse _pulse;

        private RsSmab_Source_LfOutput_Shape_Trapeze _trapeze;

        private RsSmab_Source_LfOutput_Shape_Triangle _triangle;

        //
        // Сводка:
        //     Pulse commands group
        //     Sub-classes count: 3
        //     Commands count: 0
        //     Total commands count: 3
        public RsSmab_Source_LfOutput_Shape_Pulse Pulse => _pulse ?? (_pulse = new RsSmab_Source_LfOutput_Shape_Pulse(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Trapeze commands group
        //     Sub-classes count: 4
        //     Commands count: 0
        //     Total commands count: 4
        public RsSmab_Source_LfOutput_Shape_Trapeze Trapeze => _trapeze ?? (_trapeze = new RsSmab_Source_LfOutput_Shape_Trapeze(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Triangle commands group
        //     Sub-classes count: 2
        //     Commands count: 0
        //     Total commands count: 2
        public RsSmab_Source_LfOutput_Shape_Triangle Triangle => _triangle ?? (_triangle = new RsSmab_Source_LfOutput_Shape_Triangle(_grpBase.Core, _grpBase));

        internal RsSmab_Source_LfOutput_Shape(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Shape", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_Source_LfOutput_Shape Clone()
        {
            RsSmab_Source_LfOutput_Shape rsSmab_Source_LfOutput_Shape = new RsSmab_Source_LfOutput_Shape(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_Source_LfOutput_Shape);
            return rsSmab_Source_LfOutput_Shape;
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe
        //     Selects the waveform shape of the LF signal.
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        //
        // Параметры:
        //   shape:
        //     SINE| SQUare| PULSe| TRIangle| TRAPeze
        public void Set(LfShapeBfAmilyEnum shape)
        {
            Set(shape, LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe
        //     Selects the waveform shape of the LF signal.
        //
        // Параметры:
        //   shape:
        //     SINE| SQUare| PULSe| TRIangle| TRAPeze
        //
        //   lfOutput:
        //     Repeated capability selector
        public void Set(LfShapeBfAmilyEnum shape, LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            _grpBase.IO.Write("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe " + shape.ToScpiString());
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe
        //     Selects the waveform shape of the LF signal.
        //     shape: SINE| SQUare| PULSe| TRIangle| TRAPeze
        //     Used Repeated Capabilities default values:
        //     LfOutputRepCap.Nr1 (settable in the interface "LfOutput")
        public LfShapeBfAmilyEnum Get()
        {
            return Get(LfOutputRepCap.Default);
        }

        //
        // Сводка:
        //     [SOURce<HW>]:LFOutput<CH>:SHAPe
        //     Selects the waveform shape of the LF signal.
        //     shape: SINE| SQUare| PULSe| TRIangle| TRAPeze
        //
        // Параметры:
        //   lfOutput:
        //     Repeated capability selector
        public LfShapeBfAmilyEnum Get(LfOutputRepCap lfOutput)
        {
            string repCapCmdValue = _grpBase.GetRepCapCmdValue(lfOutput);
            return _grpBase.IO.QueryString("SOURce<HwInstance>:LFOutput" + repCapCmdValue + ":SHAPe?").ToScpiEnum<LfShapeBfAmilyEnum>();
        }
    }
}
