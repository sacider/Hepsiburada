using HepsiBurada.Model;
using System;
using System.Collections.Generic;

namespace HepsiBurada
{
    class Program
    {
        static readonly string[] Directions = { "N", "E", "S", "W" };
        static readonly string data1 = "5 5";
        static readonly string data2 = "1 2 N";
        static readonly string data3 = "LMLMLMLMM";
        static readonly string data4 = "3 3 E";
        static readonly string data5 = "MMRMMRMRRM";

        static void Main(string[] args)
        {
            GeneralModel generalModel = new GeneralModel();
            generalModel.RoverModel = new List<RoverModel>();
            generalModel.SizeRectangle = new int[] { Convert.ToInt32(data1.Split(" ")[0]), Convert.ToInt32(data1.Split(" ")[1]) };

            generalModel.RoverModel.Add(new RoverModel
            {
                StartPoint = new string[] { data2.Split(" ")[0], data2.Split(" ")[1], data2.Split(" ")[2] },
                Direction = data3
            });

            generalModel.RoverModel.Add(new RoverModel
            {
                StartPoint = new string[] { data4.Split(" ")[0], data4.Split(" ")[1], data4.Split(" ")[2] },
                Direction = data5
            });

            List<string> response = Run(generalModel);

            for (int i = 0; i < response.Count; i++)
            {
                Console.WriteLine(response[i]);
            }
        }

        static List<string> Run(GeneralModel generalModel)
        {
            List<string> result = new List<string>();

            for (int x = 0; x < generalModel.RoverModel.Count; x++)
            {
                int[] point = { Convert.ToInt32(generalModel.RoverModel[x].StartPoint[0]), Convert.ToInt32(generalModel.RoverModel[x].StartPoint[1]) };

                string lastDirection = generalModel.RoverModel[x].StartPoint[2];

                foreach (var item2 in generalModel.RoverModel[x].Direction.ToCharArray())
                {
                    if (item2.ToString() == "L" || item2.ToString() == "R")
                    {
                        lastDirection = DirectionChange(lastDirection, item2.ToString());
                    }
                    else if (item2.ToString() == "M")
                    {
                        if (lastDirection == "N")
                        {
                            point[1]++;
                        }
                        else if (lastDirection == "E")
                        {
                            point[0]++;
                        }
                        else if (lastDirection == "S")
                        {
                            point[1]--;
                        }
                        else if (lastDirection == "W")
                        {
                            point[0]--;
                        }

                        if (point[0] > generalModel.SizeRectangle[0] || point[1] > generalModel.SizeRectangle[1])
                        {
                            Console.Write("The robot went out of the drawn area.");
                        }
                    }
                }
                result.Add(point[0].ToString() + " " + point[1].ToString() + " " + lastDirection);
            }
            return result;
        }

        static string DirectionChange(string oldDirection, string DirectionToTurn)
        {
            for (int i = 0; i < Directions.Length; i++)
            {
                if (Directions[i] == oldDirection)
                {
                    if (DirectionToTurn == "R")
                    {
                        i++;
                        return Directions[i > 3 ? 0 : i];
                    }
                    else if (DirectionToTurn == "L")
                    {
                        i--;
                        return Directions[i < 0 ? 3 : i];
                    }
                }
            }
            Console.Write("Wrong direction command!");
            return "";
        }
    }
}
