using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.IO;
using System.Threading.Tasks;

namespace LeagueLibrary
{
    public class Class1
    {
        /*
         * zet de Entities classes public  
         * zet de Data classes public static  
         * zet de Interface public  
         *
         * -- Entities
         * begin met de Eigenschappen                                     public string Name {get; set;}
         * zet de ToString method er ook al in                             (constructor volgt later) 
         * 
         * -- Interface
         *  begin met de Eigenschappen                                      int Winner {get; set;}
         *  void method kan je ook al toevoegen hier hoeft geen code in      void DecideWinner();
         * 
         * -- Data
         * begin met de Eigenschappen                               private static Random R = new Random();
         * method om datatable aan te maken (LoadCSV)               **zie 50 - 80 
         * method datatabel naar dataview                           **zie 95 - 105 
                                        *                                   *  return banDataTable.AsDataView();
         * 
         * method waarbij je moet filter doe je als laatste 
         * 
         * 
         * --WPF 
         * combobox   
         * loading 
         * closing 
         * 
         * 
         * 
         * using System.Data;
         * using System.Linq;
         * using System.IO;
         * using Path = System.IO.Path;
         * using Microsoft.Win32;   
         


        ---------------------------------------------------------------------------------------------------------------------

        ///// Publieke abstracte methode
        * maak de class ook abstract
        * method heeft geen body omdat deze abstract is 

        * classes dat erft van een abstract word ook abstract
        *




        ---------------------------------------------------------------------------------------------------------------------
        
        //// LoadCSV :  zorgt er voor dat de DataTable geïnitialiseerd is.
                                                          *       banDataTabel = new DataTable("ban")
        *  rijen afgaan en eerst rij als tabelnamen nemen 
                                                          *       string[] lines = File.ReadAllLines(padNaarCsv);
                                                                  string[] headers = lines[0].Split(';');   /// pakt de eerte rij van de file en gebruit deze waarden als headers 
                                                                  int index = 0;
        *  (Column) kolommen aanmaken  (naam geven)         
                                                    *             DataColumn columnName = new DataColumn(headers[index++], typeof(string));
        *  kollomen range meegeven 
                                  *                               banDataTable.Columns.AddRange(new DataColumn[]
                                  *                               {
                                  *                                     columnName,... 
                                  *                               });
                                  *                               
         
        *  DataTable te vullen met records
                                       *                          lines.Skip(1).ToList().ForEach(t =>
                                                                        {
                                                                            string[] data = t.Split(';');
                                                                            if (string.IsNullOrEmpty(data[5]))
                                                                            {
                                                                                data[5] = null;
                                                                            }

                                                                            if (string.IsNullOrEmpty(data[6]))
                                                                            {
                                                                                data[6] = null;
                                                                            }

                                                                            DataTableChampions.Rows.Add(data);
                                                                        });

        ----------------------------
        //// LoadCSV  List te vullen met Ability objecten.
                                                *
                                                * public static void LoadCSV(string padNaarCsv)
                                                {
                                                    Abilities = new List<Ability>();
                                                    try
                                                    {
                                                        string[] lines = File.ReadAllLines(padNaarCsv);

                                                        for (int i = 1; i < lines.GetLength(0); i++)
                                                        {
                                                            string[] data;
                                                            data = lines[i].Split(';');

                                                            int abilityId = int.Parse(data[0]);
                                                            string championName = data[1];
                                                            string abilityName = data[2];
                       

                                                            Abilities.Add(new Ability(abilityId, championName , abilityName);
                                                        }
                                                    }
                                                    catch
                                                    {
                                                        Abilities = null;
                                                        throw new Exception("Wrong file format!");
                                                    }
                                                }
                                                *








         ---------------------------------------------------------------------------------------------------------------------
        ////  zet de data uit banDataTable om naar een DataView.
        ///
                    *  if (banDataTable != null)
                        {
                            return banDataTable.AsDataView();
                        }

                        throw new Exception("Datagrid is null!");

         ---------------------------------------------------------------------------------------------------------------------
         

        ////// Constructor met een parameter voor elke eigenschap.
       *      public Champion(string name, string title, string @class, int releaseYear, List<Ability> abilities, List<string> positions, string iconSource, string bannerSource, int costIp, int costRp)
                {
                    Name = name;
                    Title = title;
                    Class = @class;
                    ReleaseYear = releaseYear;
                    Abilities = abilities;
                    Positions = positions;
                    IconSource = iconSource;
                    BannerSource = bannerSource;
                    CostIP = costIp;
                    CostRP = costRp;
                }

        ---------------------------------------------------------------------------------------------------------------------
        */

    }
}
