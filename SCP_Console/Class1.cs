using System;
using System.IO;
using System.Collections.Generic;
using SCP;
using BiomeLibrary;
using System.Linq;
using System.Configuration;
using Newtonsoft.Json;

namespace SCP_Console
{
    public class Interface
    {
        private const string rootPath = @"C:\Main\Cs\SCP\Tests\Project";
        private const string settPath = @"C:\\WinTools\Files\SCP\BGDF\settings.bgdf";
        private string projPath = "";
        private Bowl settings = new Bowl(settPath);

        //default assets
        string blackBlock = @"‰PNG\r\n\u001a\r\n   \r\nIHDR   \u0001   \u0001\b\u0006   \u001f\u0015Ä‰   \r\nIDAT\u0018Wc```ø\u000f \u0001\u0004\u0001 p e\r\n    IEND®B`‚  ";
        public void Hub()
        {
            Next.Title("Scratch Compiler Interface");
            Next.Err("A frontal Interface has not yet been developed for this utility. Use CI (or virtual CI) to access to API");
            return;
        }
        public void Setup()
        {
            Next.Title("SCP Setup");
            Next.Err("do you want to proceed(it will delete all the directories and reinstall everything, concludingly deleting the project folder, which may still hold your projects.) [y/n]");
            Console.WriteLine();
            string answer = Next.Arg();
            if(answer != "y")
            {
                Next.Err("setup failed. returning.");
                return;
            }
            if(Directory.Exists(rootPath))
            {
                Directory.Delete(rootPath, true);
            }
            Next.Adv("creating files");
            Directory.CreateDirectory(rootPath);
            Directory.CreateDirectory(rootPath + "BGDF");
            Directory.CreateDirectory(rootPath + "Proj");
            Next.Adv("accessing settings Bowl");
            settings = new Bowl(settPath);
            settings.Set("projectPath", rootPath + "Proj");
            Next.Title("Setup complete");
            return;
        }
        public void Handle(string[] input, string root)
        {
            GetSettings();
            string[] command = RemoveFirst(input);
            if (command == null)
            {
                Next.Err("command not found");
                return;
            }
            switch (command[0])
            {
                case "settings":

                    switch(command[1])
                    {
                        case "call":
                            VisualizeSettings();
                            break;
                        default:
                            Next.Err("command not found");
                            break;
                    }
                    break;
                case "new":

                    switch(command[1])
                    {
                        case "proj":
                            if(command.Length > 2)
                            {
                                CreateProject(command[2]);
                                break;
                            }
                            CreateProject(rootPath);
                            break;
                        default:
                            Next.Err("command not found");
                            break;
                    }
                    break;
                case "assets":

                    switch(command[1])
                    {
                        case "rebuild":
                            File.Create(@"C:\Main\Cs\SCP\Assets\black1.png").Close();
                            File.WriteAllText(@"C:\Main\Cs\SCP\Assets\black1.png", blackBlock);
                            break;
                        default:
                            Next.Err("command not found1");
                            break;
                    }
                    break;
                case "project":

                    switch(command[1])
                    {
                        case "compile":
                            Next.Adv("compiling project solution");
                            try
                            {
                                CompileProject();
                            }
                            catch(Exception ex)
                            {
                                Next.Err(ex.Message);
                            }
                            break;
                        default:
                            Next.Err("command not found1");
                            break;
                    }
                    break;
                default:
                    Next.Err("command not found");
                    return;
            }
        }

        //Project methods
        public void CreateProject(string rootPath)
        {
            Next.Adv("creating project solution");
            if(!Directory.Exists(rootPath))
            {
                Next.Err("an error has occured");
                return;
            }
            //initializing folders
            Next.Adv("initializing folders");
            Directory.CreateDirectory(rootPath + @"\Assets");
            Directory.CreateDirectory(rootPath + @"\Scripts");
            Directory.CreateDirectory(rootPath + @"\Export");

            //initializing files
            File.Create(rootPath + @"\project.scpf").Close();
            File.Create(rootPath + @"\ref.bgdf").Close();
            File.Create(rootPath + @"\scene.scsf").Close();

            //initializing bowls
            Next.Adv("initializing bowls");
            Bowl projectFile = new Bowl(rootPath + @"\project.scpf");
            Bowl linkFile = new Bowl(rootPath + @"\ref.bgdf");
            Bowl sceneFile = new Bowl(rootPath + @"\scene.scsf");

            Next.Adv("filling and preparing bowls");
            //filling and preparing bowls
            projectFile.Set("version", "0.0.1");
            projectFile.Set("linkFile", @"res:\\ref.bgdf");

            linkFile.Set("black", @"res:\\Assets\black.png");

            sceneFile.Set("name", "Stage");
            sceneFile.Set("script", new string[] { @"res:\\Scripts\stage.pcss" });
            sceneFile.Set("costumes", new string[] { "black" });
            //sceneFile.Set("sounds", new string[0]);
            sceneFile.Set("volume", 100);
            sceneFile.Set("layerOrder", 0);
            sceneFile.Set("tempo", 60);

        }

        public void CompileProject()
        {
            Next.Title("starting compile");
            //create output folder
            Directory.CreateDirectory(rootPath + @"\Export\Project");
            Next.Adv(".");

            //standard settings without variables
            JsonFile file = new JsonFile();
            file.monitors = new Monitor[] {};
            file.extensions = new object[] {};
            file.meta = new Meta();
            Next.Adv(".");

            //create Stage object
            Target Stage = new Target("Stage", (BlockContainer)new object());
            Stage.isStage = true;
            Stage.currentCostume = 0;
            Costume cost = new Costume("black", 0, "svg", "random", 0, 0);
            Stage.costumes = new Costume[] { cost };
            Stage.sounds = new Sound[0];
            Stage.volume = 100;
            Stage.layerOrder = 0;
            Stage.tempo = 60;
            Stage.videoTransparency = 50;
            Stage.videoState = "on";
            Stage.textToSpeechLanguage = null;
            Next.Adv(".");

            file.targets = new Target[] { Stage };
            Next.Adv(".");

            string json = "my bals itch";//JsonConvert.SerializeObject(file);
            Next.Adv(".");
            File.WriteAllText(rootPath + @"\Export\Project\project.json", json);
            Next.Adv("all done. project compiled. now pray for it to work");
        }

        //Settings methods
        public void GetSettings()
        {
            projPath = (string)settings.Get("projectPath");
        }
        public void VisualizeSettings()
        {
            GetSettings();

            string[] visualizedSettings = new string[1];

            visualizedSettings[0] = "default project path:     " + projPath;

            Next.Title("current settings:");
            Next.List(visualizedSettings);
        }

        //other methods
        public string[] RemoveFirst(string[] input)
        {
            string[] output = new string[input.Length - 1];
            for(int i = 1; i < input.Length; i++)
            {
                output[i - 1] = input[i];
            }
            return output;
        }
    }
    public class Next
    {
        public static string Cmd()
        {
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("cmd>    ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        public static string Arg()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("arg>    ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }
        public static void Title(string text)
        {
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine(text);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public static void Adv(string text)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(text);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Err(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void List(string[] input)
        {
            Console.WriteLine();
            if (input != null)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                foreach (string i in input)
                {
                    Console.WriteLine(i);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("none");
            }
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
