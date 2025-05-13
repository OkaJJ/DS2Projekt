namespace DS2_Projekt.Models;
//
// CREATE TABLE diagnosis (
//     diagnosis_id int PRIMARY KEY,
//     code varchar2(10),
//     name varchar2(255)
// );

public class Diagnosis {
    public int diagnosis_id { get; set; }
    public string code { get; set; }
    public string name { get; set; }
}