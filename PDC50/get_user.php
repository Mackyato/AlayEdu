

<?php
include 'db.php';
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
// In this example, we just select all users. If you have filtering parameters, handle them here.

$sql = "SELECT ID, Firstname, Lastname, Email, ContactNo, Course, PresentCount, AbsentCount, LastEnrolledTerm, CourseYear FROM tblstudents";
$result = $conn->query($sql);

$users = [];

if ($result) {
    while ($row = $result->fetch_assoc()) {
        $users[] = $row;
    }
    $result->close();
} else {
    http_response_code(500);
    echo json_encode(["message" => "Error fetching users: " . $conn->error]);
    $conn->close();
    exit;
}

$conn->close();

// Return the list of users as JSON
http_response_code(200);
echo json_encode($users);

