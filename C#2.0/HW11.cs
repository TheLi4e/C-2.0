using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;

namespace C_2._0
{
    internal class HW11
    {
        internal static void Run()
        {
            try
            {
                TestClass testClass = new TestClass(1, "string", 1232131, 's');
                Console.Write("Объект вида: ");
                Console.WriteLine(testClass.ToString()); 
                
                string jsonInput = JsonSerializer.Serialize(testClass);
                Console.Write("Преобразуем в JSON: ");
                Console.WriteLine(jsonInput);

                using (JsonDocument doc = JsonDocument.Parse(jsonInput))
                {
                    
                    XmlDocument xmlDocument = new XmlDocument();
                    XmlElement root = xmlDocument.CreateElement("root");
                    xmlDocument.AppendChild(root);
                                       
                    ConvertJsonToXml(doc.RootElement, root);
                                   
                    Console.Write("Преобразуем в XML: ");
                    Console.WriteLine(xmlDocument.OuterXml);
                }
            }
            catch (JsonException e)
            {
                Console.WriteLine($"Ошибка при парсинге JSON: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Произошла ошибка: {e.Message}");
            }
        }
        static void ConvertJsonToXml(JsonElement json, XmlElement xml)
        {
            foreach (var property in json.EnumerateObject())
            {
                XmlElement xml1 = xml.OwnerDocument.CreateElement(property.Name);

                if (property.Value.ValueKind == JsonValueKind.Object)
                {
                    ConvertJsonToXml(property.Value, xml1);
                }
                else if (property.Value.ValueKind == JsonValueKind.Array)
                {
                    foreach (var arrayItem in property.Value.EnumerateArray())
                    {
                        XmlElement arrayElement = xml.OwnerDocument.CreateElement(property.Name);
                        ConvertJsonToXml(arrayItem, arrayElement);
                        xml1.AppendChild(arrayElement);
                    }
                }
                else
                {
                    xml1.InnerText = property.Value.ToString();
                }

                xml.AppendChild(xml1);
            }
        }
    }
}

