<?php
include 'db.php';

$data = json_decode(file_get_contents("php://input"));
if (!isset($data->id, $data->userId, $data->schoolYear, $data->term, $data->paymentSchedule, $data->requiredAmount, $data->cumulativeBalance)) {
    http_response_code(400);
    echo json_encode(["message" => "Invalid input"]);
    exit;
}

$id = intval($data->id);
$userId = intval($data->userId);
$schoolYear = htmlspecialchars(strip_tags($data->schoolYear));
$term = htmlspecialchars(strip_tags($data->term));
$paymentSchedule = htmlspecialchars(strip_tags($data->paymentSchedule));
$requiredAmount = floatval($data->requiredAmount);
$cumulativeBalance = floatval($data->cumulativeBalance);

$sql = "UPDATE payment_schedules SET UserID = ?, SchoolYear = ?, Term = ?, PaymentSchedule = ?, RequiredAmount = ?, CumulativeBalance = ? WHERE ID = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("isssddi", $userId, $schoolYear, $term, $paymentSchedule, $requiredAmount, $cumulativeBalance, $id);

if ($stmt->execute()) {
    http_response_code(200);
    echo json_encode(["message" => "Payment schedule updated successfully"]);
} else {
    http_response_code(500);
    echo json_encode(["message" => "Error updating payment schedule: " . $stmt->error]);
}

$stmt->close();
$conn->close();
