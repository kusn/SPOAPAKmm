using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_Format
    {
        private readonly CommandsGroup _grpBase;

        //
        // Сводка:
        //     FORMat:BORDer
        //     Determines the sequence of bytes within a binary block. This only affects blocks
        //     which use the IEEE754 format internally.
        //     border: NORMal| SWAPped NORMal Expects/sends the least significant byte of each
        //     IEEE754 floating-point number first and the most significant byte last. SWAPped
        //     Expects/sends the most significant byte of each IEEE754 floating-point number
        //     first and the least significant byte last.
        public ByteOrderEnum Border
        {
            get
            {
                return _grpBase.IO.QueryString("FORMat:BORDer?").ToScpiEnum<ByteOrderEnum>();
            }
            set
            {
                _grpBase.IO.Write("FORMat:BORDer " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     FORMat:SREGister
        //     Determines the numeric format for responses of the status register.
        //     format: ASCii| BINary| HEXadecimal| OCTal ASCii Returns the register content
        //     as a decimal number. BINary|HEXadecimal|OCTal Returns the register content either
        //     as a binary, hexadecimal or octal number. According to the selected format, the
        //     number starts with #B (binary) , #H (hexadecimal) or #O (octal) .
        public FormStatRegEnum Sregister
        {
            get
            {
                return _grpBase.IO.QueryString("FORMat:SREGister?").ToScpiEnum<FormStatRegEnum>();
            }
            set
            {
                _grpBase.IO.Write("FORMat:SREGister " + value.ToScpiString());
            }
        }

        //
        // Сводка:
        //     FORMat:[DATA]
        //     Determines the data format the instrument uses to return data via the IEC/IEEE
        //     bus. The instrument automatically detects the data format used by the controller,
        //     and assigns it accordingly. Data format determined by this SCPI command is in
        //     this case irrelevant.
        //     data: ASCii| PACKed ASCii Transfers numerical data as plain text separated by
        //     commas. PACKed Transfers numerical data as binary block data. The format within
        //     the binary data depends on the command. The various binary data formats are explained
        //     in the description of the parameter types.
        public FormDataEnum Data
        {
            get
            {
                return _grpBase.IO.QueryString("FORMat:DATA?").ToScpiEnum<FormDataEnum>();
            }
            set
            {
                _grpBase.IO.Write("FORMat:DATA " + value.ToScpiString());
            }
        }

        internal RsSmab_Format(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("Format", core, parent);
        }
    }
}
