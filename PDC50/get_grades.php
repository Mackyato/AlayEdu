<?php
include 'db.php';
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");

// Get StudentID from the query parameter (e.g., ?StudentID=1)
$studentID = isset($_GET['StudentID']) ? $_GET['StudentID'] : null;

// If StudentID is not provided, return an error
if ($studentID === null) {
    http_response_code(400);
    echo json_encode(["message" => "StudentID is required"]);
    exit;
}

// Fetch grades from the tblgrades table where StudentID matches
$sql = "SELECT GradeID, StudentID, SubjectName, Term, SchoolYear, Grade, Remarks, DateRecorded FROM tblgrades WHERE StudentID = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $studentID);
$stmt->execute();

$result = $stmt->get_result();

$grades = [];

if ($result->num_rows > 0) {
    // Fetch results and store in an array
    while ($row = $result->fetch_assoc()) {
        $grades[] = $row;
    }
} else {
    http_response_code(404);
    echo json_encode(["message" => "No grades found for StudentID " . $studentID]);
    $stmt->close();
    $conn->close();
    exit;
}

$stmt->close();
$conn->close();

// Return the list of grades as JSON
http_response_code(200);
echo json_encode($grades);
?>