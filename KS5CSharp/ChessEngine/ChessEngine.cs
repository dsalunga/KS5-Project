#region Using directives
using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
#endregion

namespace KS5.ChessEngine
{
    public class Engine : IDisposable
    {
        private Process proc;
        private StreamWriter writer;
        private StreamReader reader;
        private string line;
        private string move;

        public Engine()
        {
            proc = new Process();

            proc.StartInfo.FileName = "ruffian/ruffian.exe";
            proc.StartInfo.WorkingDirectory = "ruffian";
            proc.StartInfo.Arguments = "";
            proc.StartInfo.UseShellExecute = false;
            proc.StartInfo.RedirectStandardError = true;
            proc.StartInfo.RedirectStandardInput = true;
            proc.StartInfo.RedirectStandardOutput = true;
            proc.StartInfo.CreateNoWindow = true;

            proc.Start();

            writer = proc.StandardInput;
            reader = proc.StandardOutput;
        }

        public string GetNextMove(string m)
        {

            writer.WriteLine(m);
            writer.Flush();

            writer.WriteLine("stop");
            writer.Flush();

            writer.WriteLine("stop");
            writer.Flush();

            do
            {
                line = reader.ReadLine();

                if (line.StartsWith("bestmove"))
                {
                    move = line.Substring(9, 4);
                    writer.WriteLine(move);
                    writer.Flush();
                }
            } while (!line.StartsWith("bestmove"));

            return move;
        }

        public string GetNextMove2()
        {

            //writer.WriteLine(m);
            //writer.Flush();

            writer.WriteLine("stop");
            writer.Flush();

            writer.WriteLine("stop");
            writer.Flush();

            do
            {
                line = reader.ReadLine();

                if (line.StartsWith("bestmove"))
                {
                    move = line.Substring(9, 4);
                    writer.WriteLine(move);
                    writer.Flush();
                }
            } while (!line.StartsWith("bestmove"));

            return move;
        }

        public void writeMove(string m)
        {
            writer.WriteLine(m);
            writer.Flush();
        }


        public string GetNextMove()
        {

            
            writer.WriteLine("stop");
            writer.Flush();

            do
            {

                line = reader.ReadLine();
                if (line.StartsWith("bestmove"))
                {
                    move = line.Substring(9, 4);
                    writer.WriteLine(move);
                    writer.Flush();
                }

            } while (!line.StartsWith("bestmove"));

            return move;
        }


        public void initengine()
        {
            writer.WriteLine("uci");
            writer.WriteLine("isready");
            writer.WriteLine("position startpos");
            writer.Flush();
        }

        public void AbortMove()
        {
            writer.WriteLine("stop");
            writer.Flush();
        }


        public void Dispose()
        {
            writer.WriteLine("quit");
            writer.Flush();

            proc.Close();
        }


    }
}
