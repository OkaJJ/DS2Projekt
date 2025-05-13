namespace DS2_Projekt.Models;

// CREATE TABLE doctor (
//     doctor_id int PRIMARY KEY,
//     first_name varchar2(100),
//     last_name varchar2(100),
//     specialization varchar2(100)
// );

public class Doctor {
    public int doctor_id { get; set; }
    public string first_name { get; set; }
    public string last_name { get; set; }
    public string specialization { get; set; }
}