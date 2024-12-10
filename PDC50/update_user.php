<?php
include 'db.php';

// Decode JSON input
$data = json_decode(file_get_contents("php://input"));

// Validate input
if (!isset($data->id) || !isset($data->firstname) || !isset($data->lastname) || !isset($data->email) || !isset($data->contactNo) || !isset($data->course)) {
    http_response_code(400);
    echo json_encode(["message" => "Invalid input"]);
    exit;
}

// Sanitize input
$id = intval($data->id);
$firstname = htmlspecialchars(strip_tags($data->firstname));
$lastname = htmlspecialchars(strip_tags($data->lastname));
$email = htmlspecialchars(strip_tags($data->email));
$contactNo = htmlspecialchars(strip_tags($data->contactNo));
$course = htmlspecialchars(strip_tags($data->course));

// Use prepared statements for security
$sql = "UPDATE tblstudents SET Firstname = ?, Lastname = ?, Email = ?, ContactNo = ?, Course = ? WHERE ID = ?";
$stmt = $conn->prepare($sql);

if ($stmt) {
    $stmt->bind_param("sssssi", $firstname, $lastname, $email, $contactNo, $course, $id);
    if ($stmt->execute()) {
        http_response_code(200);
        echo json_encode(["message" => "User updated successfully"]);
    } else {
        http_response_code(500);
        echo json_encode(["message" => "Error updating user: " . $stmt->error]);
    }
    $stmt->close();
} else {
    http_response_code(500);
    echo json_encode(["message" => "Error preparing statement: " . $conn->error]);
}

$conn->close();
?>
