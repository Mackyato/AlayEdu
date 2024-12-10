<?php
include 'db.php';

// Decode JSON input
$data = json_decode(file_get_contents("php://input"));

// Validate input
if (!isset($data->firstname) ||
    !isset($data->lastname) ||
    !isset($data->email) ||
    !isset($data->contactNo) ||
    !isset($data->course) ||
    !isset($data->lastEnrolledTerm) ||
    !isset($data->courseYear)) {
    http_response_code(400);
    echo json_encode(["message" => "Invalid input"]);
    exit;
}

// Sanitize input
$firstname = htmlspecialchars(strip_tags($data->firstname));
$lastname = htmlspecialchars(strip_tags($data->lastname));
$email = htmlspecialchars(strip_tags($data->email));
$contactNo = htmlspecialchars(strip_tags($data->contactNo));
$course = htmlspecialchars(strip_tags($data->course));
$lastEnrolledTerm = htmlspecialchars(strip_tags($data->lastEnrolledTerm));
$courseYear = htmlspecialchars(strip_tags($data->courseYear));

// Insert user
$sql = "INSERT INTO tblstudents (Firstname, Lastname, Email, ContactNo, Course, LastEnrolledTerm, CourseYear)
        VALUES (?, ?, ?, ?, ?, ?, ?)";
$stmt = $conn->prepare($sql);

if ($stmt) {
    $stmt->bind_param("sssssss", $firstname, $lastname, $email, $contactNo, $course, $lastEnrolledTerm, $courseYear);
    if ($stmt->execute()) {
        http_response_code(200);
        echo json_encode(["message" => "User added successfully"]);
    } else {
        http_response_code(500);
        echo json_encode(["message" => "Error adding user: " . $stmt->error]);
    }
    $stmt->close();
} else {
    http_response_code(500);
    echo json_encode(["message" => "Error preparing statement: " . $conn->error]);
}

$conn->close();
