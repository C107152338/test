using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string filePath = @"./App_Data/opendata109b141.csv";
            var lines = System.IO.File.ReadAllLines(filePath);

            var datas = lines.ToList().Skip(1).Select(x =>
            {
                var columns = x.Split(',');
                var item = new Data()
                {
                    statistic_yyy = columns[0],
                    according = columns[1],
                    district_code = columns[2],
                    site_id = columns[3],
                    sex = columns[4],
                    father_age = columns[5],
                    mother_age = columns[6],
                    birth_count = columns[7],
                };
                return item;
            });
            datas.ToList();

            var count = 0;
            foreach (var data in datas)
            {
                Console.Write(data.statistic_yyy + '\t');
                Console.Write(data.according + '\t');
                Console.Write(data.district_code + '\t');
                Console.Write(data.site_id + '\t');
                Console.Write(data.sex + '\t');
                Console.Write(data.father_age + '\t');
                Console.Write(data.mother_age + '\t');
                Console.Write(data.birth_count + '\t');
                Console.WriteLine();
                ++count;

                if (count == 100) break;
            }

            Console.WriteLine("0:統計年度, 1:按照別, 2:區域別代碼, 3:區域別, 4:嬰兒性別, 5:生父年齡, 6:生母年齡, 7:嬰兒出生數");
            Console.Write("查詢:");
            string lookfor = Console.ReadLine();
            Console.Write("字串:");
            string str = Console.ReadLine();

            count = 0;
            foreach (var data in datas)
            {
                List<string> d = new List<string>();
                d.Add(data.statistic_yyy);
                d.Add(data.according);
                d.Add(data.district_code);
                d.Add(data.site_id);
                d.Add(data.sex);
                d.Add(data.father_age);
                d.Add(data.mother_age);
                d.Add(data.birth_count);

                if (d[Int32.Parse(lookfor)] == str)
                {
                    foreach (var l in d)
                    {
                        Console.Write(l + '\t');
                    }
                    Console.WriteLine();
                    count++;
                }
            }

            Console.WriteLine(string.Format("共計{0}筆資料", count));
        }
    }
}
