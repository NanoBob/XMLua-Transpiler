using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;

namespace XMLua_Compiler
{
    class Compiler
    {
        private FileSystemWatcher watcher;

        private string rootDirectory;
        private string src;
        private string bin;
        private string fileType;
        private XmlDocument meta;
        private XmlElement root;
        private List<XmlElement> elements;

        static void Main(string[] args)
        {
            new Compiler();
        }

        public Compiler()
        {
            rootDirectory = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

            ParseConfig();

            watcher = new FileSystemWatcher(rootDirectory + "//" + src);
            watcher.IncludeSubdirectories = true;

            Console.WriteLine("Adding Handlers");
            watcher.Changed += new FileSystemEventHandler(OnChange);
            watcher.Created += new FileSystemEventHandler(OnCreate);
            watcher.Deleted += new FileSystemEventHandler(OnDelete);
            watcher.Renamed += new RenamedEventHandler(OnRename);

            CompileAll();
            while (true)
            {
                watcher.WaitForChanged(WatcherChangeTypes.All);
            }
        }

        public void OnChange(object source, FileSystemEventArgs e)
        {
            Compile(e.FullPath);
        }

        public void OnCreate(object source, FileSystemEventArgs e)
        {
            Compile(e.FullPath);
        }

        public void OnDelete(object source, FileSystemEventArgs e)
        {
            Compile(e.FullPath);
        }

        public void OnRename(object source, FileSystemEventArgs e)
        {
            Compile(e.FullPath);
        }


        public void CompileAll()
        {
            if (Directory.Exists(rootDirectory + "//" + src))
            {
                string[] files = Directory.GetFiles(rootDirectory + "//" + src, "*", SearchOption.AllDirectories);
                foreach (string filepath in files)
                {
                    Compile(filepath);
                }
            }
        }

        public void Compile(string path)
        {
            try
            {
                XmlDocument file = new XmlDocument();
                file.Load(path);

                XmlNode rootNode = file.ChildNodes[0];
                INodeCompiler compiler = CompilerFactory.Create(rootNode);
                string script = compiler.Compile(rootNode);

                string newPath = Utils.ReplaceLastOccurrence(path, src, bin).Replace("." + fileType, ".lua");
                if (File.Exists(newPath))
                {
                    File.Delete(newPath);
                }
                File.WriteAllText(newPath, script);
            } catch (XmlException e)
            {
                Console.WriteLine("Syntax error in {0}", path);
                Console.WriteLine(e);
            }
        }


        public void ParseConfig()
        {

            XmlDocument config = new XmlDocument();
            config.Load(rootDirectory + "/config.xml");
            src = "src";
            bin = "bin";
            fileType = "xmlua";

            foreach (XmlElement node in config.ChildNodes[0].ChildNodes)
            {
                switch (node.Name)
                {
                    case "src":
                        Console.WriteLine("Setting src to '{0}'", node.InnerXml);
                        src = node.InnerXml;
                        break;
                    case "bin":
                        Console.WriteLine("Setting bin to '{0}'", node.InnerXml);
                        bin = node.InnerXml;
                        break;
                    case "fileType":
                        Console.WriteLine("Setting file type to '{0}'", node.InnerXml);
                        fileType = node.InnerXml;
                        break;
                }
            }
        }

    }
}
