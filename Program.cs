using System;
using System.IO;

namespace U6_Csharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            FileStream mFileReader = null;
            FileStream mFileWriter = null;
            BinaryWriter Writer = null;
            BinaryReader Reader = null;

            try
            {
                mFileWriter = new FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Write);
                Writer = new BinaryWriter(mFileWriter);
                Writer.Write("Sarahi");
                Writer.Write(23);
                Writer.Write(1.60);
                Writer.Write('F');

                Writer.Write("Enrique");
                Writer.Write(48);
                Writer.Write(1.62);
                Writer.Write('M');
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error writing to file: " + ex.Message);
            }
            finally
            {
                if (Writer != null) Writer.Close();
                if (mFileWriter != null) mFileWriter.Close();
            }

            try
            {
                mFileReader = new FileStream("data.dat", FileMode.OpenOrCreate, FileAccess.Read);
                Reader = new BinaryReader(mFileReader);

                while (mFileReader.Position != mFileReader.Length)
                {
                    Console.WriteLine(Reader.ReadString());
                    Console.WriteLine(Reader.ReadInt32());
                    Console.WriteLine(Reader.ReadDouble());
                    Console.WriteLine(Reader.ReadChar());
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("Error al leer el archivo: " + ex.Message);
            }
            finally
            {
                if (Reader != null) Reader.Close();
                if (mFileReader != null) mFileReader.Close();
            }

            Console.ReadKey();
        }
    }
}
