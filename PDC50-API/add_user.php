<?php
include 'db.php';

$data = json_decode(file_get_contents("php://input"));

$name = $data->name;
$gender = $data->gender;
$contactNo = $data->contactNo;

$sql = "INSERT INTO tblpersonal (Name, Gender, ContactNo) VALUES ('$name', '$gender', '$contactNo')";

if ($conn->query($sql) === TRUE) {
    echo json_encode(["message" => "User added successfully"]);
} else {
    echo json_encode(["message" => "Error: " . $conn->error]);
}

$conn->close();
?>
