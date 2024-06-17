//using System;
//using System.IO;
//using System.Runtime.Serialization;
//using System.Runtime.Serialization.Formatters.Binary;
//[Serializable]
//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}
//class Program
//{
//    static void Main()
//    {
//        Person p = new Person { Name = "Alice", Age = 30 };
//        using (FileStream stream = new FileStream("person.bin", FileMode.Create))
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            formatter.Serialize(stream, p);
//            Console.WriteLine("Serialized person object to file.");
//            Console.ReadKey();
//        }
//    }
//}


//using System;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;

//[Serializable]
//class Person
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//}

//class Program
//{
//    static void Main()
//    {
//        // 反序列化之前，需要确保 person.bin 文件已经存在
//        if (File.Exists("person.bin"))
//        {
//            Person p;

//            // 使用 FileStream 打开 person.bin 文件，打开模式为打开已有文件
//            using (FileStream stream = new FileStream("person.bin", FileMode.Open))
//            {
//                BinaryFormatter formatter = new BinaryFormatter();

//                // 使用 BinaryFormatter 从文件流中反序列化 Person 对象
//                p = (Person)formatter.Deserialize(stream);
//            }

//            // 输出反序列化得到的 Person 对象的属性值
//            Console.WriteLine("Deserialized person object:");
//            Console.WriteLine("Name: {0}", p.Name);
//            Console.WriteLine("Age: {0}", p.Age);
//        }
//        else
//        {
//            Console.WriteLine("person.bin 文件不存在，请先运行序列化程序来创建它。");
//        }

//        Console.ReadLine();
//    }
//}

//// 另一个例子
//using System;
//using System.IO;
//using System.Runtime.Serialization.Formatters.Binary;

//[Serializable]
//class Student
//{
//    public string Name { get; set; }
//    public int Age { get; set; }
//    public string Major { get; set; }

//    public override string ToString()
//    {
//        return $"Name: {Name}, Age: {Age}, Major: {Major}";
//    }
//}

//class Program
//{
//    static void Main()
//    {
//        // 创建一个 Student 对象
//        Student student = new Student
//        {
//            Name = "Bob",
//            Age = 21,
//            Major = "Computer Science"
//        };

//        // 序列化 Student 对象到文件
//        SerializeStudent(student);

//        // 反序列化文件中的 Student 对象并输出
//        Student deserializedStudent = DeserializeStudent();
//        if (deserializedStudent != null)
//        {
//            Console.WriteLine("Deserialized student object:");
//            Console.WriteLine(deserializedStudent);
//        }

//        Console.ReadLine();
//    }

//    static void SerializeStudent(Student student)
//    {
//        // 使用 BinaryFormatter 序列化 Student 对象到文件 "student.bin"
//        using (FileStream stream = new FileStream("student.bin", FileMode.Create))
//        {
//            BinaryFormatter formatter = new BinaryFormatter();
//            formatter.Serialize(stream, student);
//            Console.WriteLine("Serialized student object to file.");
//        }
//    }

//    static Student DeserializeStudent()
//    {
//        // 使用 BinaryFormatter 反序列化文件 "student.bin" 中的 Student 对象
//        if (File.Exists("student.bin"))
//        {
//            using (FileStream stream = new FileStream("student.bin", FileMode.Open))
//            {
//                BinaryFormatter formatter = new BinaryFormatter();
//                object obj = formatter.Deserialize(stream);

//                if (obj is Student student)
//                {
//                    return student;
//                }
//            }
//        }
//        else
//        {
//            Console.WriteLine("File 'student.bin' does not exist. Please serialize a Student first.");
//        }

//        return null;
//    }
//}


// 再一个例子

using System;
using System.IO;
using Newtonsoft.Json;

class Person
{
    public string Name { get; set; }
    public int Age { get; set; }
    public string[] Hobbies { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Age: {Age}, Hobbies: {string.Join(", ", Hobbies)}";
    }
}

class Program
{
    static void Main()
    {
        // 创建一个 Person 对象
        Person person = new Person
        {
            Name = "Alice",
            Age = 25,
            Hobbies = new string[] { "Reading", "Hiking", "Gaming" }
        };

        // 将 Person 对象序列化为 JSON 字符串
        string json = SerializeToJson(person);
        Console.WriteLine("Serialized person object to JSON:");
        Console.WriteLine(json);

        // 将 JSON 字符串反序列化为 Person 对象
        Person deserializedPerson = DeserializeFromJson(json);
        if (deserializedPerson != null)
        {
            Console.WriteLine("\nDeserialized person object:");
            Console.WriteLine(deserializedPerson);
        }

        Console.ReadLine();
    }

    static string SerializeToJson(Person person)
    {
        // 使用 Newtonsoft.Json 库将 Person 对象序列化为 JSON 字符串
        return JsonConvert.SerializeObject(person);
    }

    static Person DeserializeFromJson(string json)
    {
        // 使用 Newtonsoft.Json 库将 JSON 字符串反序列化为 Person 对象
        return JsonConvert.DeserializeObject<Person>(json);
    }
}
