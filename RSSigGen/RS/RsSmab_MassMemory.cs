using RSSigGen.InstrumentDrivers.Internal;

namespace RSSigGen.RS
{
    public class RsSmab_MassMemory
    {
        private readonly CommandsGroup _grpBase;

        private RsSmab_MassMemory_Catalog _catalog;

        private RsSmab_MassMemory_Dcatalog _dcatalog;

        private RsSmab_MassMemory_Load _load;

        private RsSmab_MassMemory_Store _store;

        //
        // Сводка:
        //     Catalog commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_MassMemory_Catalog Catalog => _catalog ?? (_catalog = new RsSmab_MassMemory_Catalog(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Dcatalog commands group
        //     Sub-classes count: 1
        //     Commands count: 1
        //     Total commands count: 2
        public RsSmab_MassMemory_Dcatalog Dcatalog => _dcatalog ?? (_dcatalog = new RsSmab_MassMemory_Dcatalog(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Load commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_MassMemory_Load Load => _load ?? (_load = new RsSmab_MassMemory_Load(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     Store commands group
        //     Sub-classes count: 1
        //     Commands count: 0
        //     Total commands count: 1
        public RsSmab_MassMemory_Store Store => _store ?? (_store = new RsSmab_MassMemory_Store(_grpBase.Core, _grpBase));

        //
        // Сводка:
        //     MMEMory:CDIRectory
        //     Changes the default directory for mass memory storage. The directory is used
        //     for all subsequent MMEM commands if no path is specified with them.
        //     directory: directory_name String containing the path to another directory. The
        //     path can be relative or absolute. To change to a higher directory, use two dots
        //     '..' .
        public string CurrentDirectory
        {
            get
            {
                return _grpBase.IO.QueryString("MMEMory:CDIRectory?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("MMEMory:CDIRectory " + value.EncloseByQuotes());
            }
        }

        //
        // Сводка:
        //     MMEMory:DRIVes
        //     No additional help available
        public string Drives => _grpBase.IO.QueryString("MMEMory:DRIVes?").TrimStringResponse();

        //
        // Сводка:
        //     MMEMory:MSIS
        //     Defines the drive or network resource (in the case of networks) for instruments
        //     with windows operating system, using msis (MSIS = Mass Storage Identification
        //     String) . Note: Instruments with Linux operating system ignore this command,
        //     since Linux does not use drive letter assignment.
        public string Msis
        {
            get
            {
                return _grpBase.IO.QueryString("MMEMory:MSIS?").TrimStringResponse();
            }
            set
            {
                _grpBase.IO.Write("MMEMory:MSIS " + value.EncloseByQuotes());
            }
        }

        internal RsSmab_MassMemory(Core core, ICmdGroup parent)
        {
            _grpBase = new CommandsGroup("MassMemory", core, parent);
        }

        //
        // Сводка:
        //     Clones the group by creating new object from it and its whole existing sub-groups
        //     Also copies all the existing default Repeated Capabilities setting, which you
        //     can change independently without affecting the original group
        public RsSmab_MassMemory Clone()
        {
            RsSmab_MassMemory rsSmab_MassMemory = new RsSmab_MassMemory(_grpBase.Core, _grpBase.Parent);
            _grpBase.SynchroniseRepCaps(rsSmab_MassMemory);
            return rsSmab_MassMemory;
        }

        //
        // Сводка:
        //     MMEMory:COPY
        //     Copies an existing file to a new file. Instead of just a file, this command can
        //     also be used to copy a complete directory together with all its files.
        //
        // Параметры:
        //   sourceFile:
        //     string String containing the path and file name of the source file
        //
        //   destinationFile:
        //     string String containing the path and name of the target file. The path can be
        //     relative or absolute. If DestinationFile is not specified, the SourceFile is
        //     copied to the current directory, queried with the method RsSmab.MassMemory.CurrentDirectory
        //     command. Note: Existing files with the same name in the destination directory
        //     are overwritten without an error message.
        public void Copy(string sourceFile, string destinationFile)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(sourceFile, 0, DataType.String), new ArgSingle(destinationFile, 1, DataType.String));
            _grpBase.IO.Write("MMEMory:COPY " + text);
        }

        //
        // Сводка:
        //     MMEMory:DELete
        //     Removes a file from the specified directory.
        //
        // Параметры:
        //   filename:
        //     string String parameter to specify the name and directory of the file to be removed.
        public void Delete(string filename)
        {
            _grpBase.IO.Write("MMEMory:DELete " + filename.EncloseByQuotes());
        }

        //
        // Сводка:
        //     MMEMory:MDIRectory
        //     Creates a subdirectory for mass memory storage in the specified directory. If
        //     no directory is specified, a subdirectory is created in the default directory.
        //     This command can also be used to create a directory tree.
        //
        // Параметры:
        //   directory:
        //     string String parameter to specify the new directory.
        public void MakeDirectory(string directory)
        {
            _grpBase.IO.Write("MMEMory:MDIRectory " + directory.EncloseByQuotes());
        }

        //
        // Сводка:
        //     MMEMory:MOVE
        //     Moves an existing file to a new location or, if no path is specified, renames
        //     an existing file.
        //
        // Параметры:
        //   sourceFile:
        //     string String parameter to specify the name of the file to be moved.
        //
        //   destinationFile:
        //     string String parameters to specify the name of the new file.
        public void Move(string sourceFile, string destinationFile)
        {
            string text = _grpBase.Core.ComposeCmdArg(new ArgSingle(sourceFile, 0, DataType.String), new ArgSingle(destinationFile, 1, DataType.String));
            _grpBase.IO.Write("MMEMory:MOVE " + text);
        }

        //
        // Сводка:
        //     MMEMory:RDIRectory
        //     Removes an existing directory from the mass memory storage system. If no directory
        //     is specified, the subdirectory with the specified name is deleted in the default
        //     directory.
        //
        // Параметры:
        //   directory:
        //     string String parameter to specify the directory to be deleted.
        public void DeleteDirectory(string directory)
        {
            _grpBase.IO.Write("MMEMory:RDIRectory " + directory.EncloseByQuotes());
        }
    }
}
