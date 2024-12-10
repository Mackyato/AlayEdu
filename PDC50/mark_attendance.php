<?php
include 'db.php';
header('Content-Type: application/json');

// Check for required parameters
if (!isset($_POST['id']) || !isset($_POST['status'])) {
    http_response_code(400);
    echo json_encode(["message" => "Missing parameters"]);
    exit;
}

$id = intval($_POST['id']);
$status = $_POST['status'];

// Determine which column to increment
$column = ($status === "Present") ? "PresentCount" : (($status === "Absent") ? "AbsentCount" : null);

if (!$column) {
    http_response_code(400);
    echo json_encode(["message" => "Invalid status"]);
    exit;
}

$sql = "UPDATE tblstudents SET $column = $column + 1 WHERE ID = ?";
$stmt = $conn->prepare($sql);

if ($stmt) {
    $stmt->bind_param("i", $id);
    if ($stmt->execute()) {
        http_response_code(200);
        echo json_encode(["message" => "Attendance updated successfully"]);
    } else {
        http_response_code(500);
        echo json_encode(["message" => "Failed to update attendance"]);
    }
    $stmt->close();
} else {
    http_response_code(500);
    echo json_encode(["message" => "Failed to prepare statement"]);
}

$conn->close();
?>
