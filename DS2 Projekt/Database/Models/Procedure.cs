namespace DS2_Projekt.Models;
// CREATE TABLE procedure (
//     procedure_id int PRIMARY KEY,
//     name varchar2(255),
//     code varchar2(20),
//     price INT
// );
public class Procedure {
    public int procedure_id { get; set; }
    public string name { get; set; }
    public string code { get; set; }
    public int price { get; set; }
}