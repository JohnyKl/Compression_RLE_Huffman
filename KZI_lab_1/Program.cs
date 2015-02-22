using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.IO;

namespace KZI_lab_1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = "";

            StreamReader sr = new StreamReader("input_file.txt", Encoding.ASCII);
            while (sr.Peek() != -1)
            {
                input = sr.ReadToEnd();     
            }

            input = RLE.encode(input);

            Console.Write("RLE encoded: " + input);   

            HuffmanTree huffmanTree = new HuffmanTree();

            // Build the Huffman tree
            huffmanTree.Build(input);

            // Encode
            BitArray encoded = huffmanTree.Encode(input);
            
            Console.Write("Huffman encoded: ");            
            foreach (bool bit in encoded)
            {

                Console.Write((bit ? 1 : 0) + "");
            }
            Console.WriteLine();


            File.WriteAllBytes("output_file.txt", ToByteArray(encoded));

            // Decode
            string decoded = huffmanTree.Decode(encoded);

            Console.WriteLine("Huffman decoded: " + decoded);

            decoded = RLE.decode(decoded);

            Console.Write("RLE decoded: " + decoded);  

            Console.ReadLine();
        }

        public static byte[] ToByteArray(BitArray bits)
        {
            const int BYTE = 8;
            int length = (bits.Count / BYTE) + ((bits.Count % BYTE == 0) ? 0 : 1);
            var bytes = new byte[length];

            for (int i = 0; i < bits.Length; i++)
            {

                int bitIndex = i % BYTE;
                int byteIndex = i / BYTE;

                int mask = (bits[i] ? 1 : 0) << bitIndex;
                bytes[byteIndex] |= (byte)mask;

            }//for

            return bytes;

        }//ToByteArray

    }
}