<?php
include 'db.php';

$userId = isset($_GET['userId']) ? intval($_GET['userId']) : 0;
$schoolYear = isset($_GET['schoolYear']) ? $_GET['schoolYear'] : '';
$term = isset($_GET['term']) ? $_GET['term'] : '';

if ($userId == 0 || empty($schoolYear) || empty($term)) {
    http_response_code(400);
    echo json_encode(["message" => "Missing parameters"]);
    exit;
}

$sql = "SELECT ID, UserID, SchoolYear, Term, DatePaid, Particulars, Credit, Balance, OldAccounts 
        FROM ledger_entries
        WHERE UserID = ? AND SchoolYear = ? AND Term = ?
        ORDER BY DatePaid ASC";

$stmt = $conn->prepare($sql);
$stmt->bind_param("iss", $userId, $schoolYear, $term);
$stmt->execute();
$result = $stmt->get_result();

$ledger = [];
while ($row = $result->fetch_assoc()) {
    $ledger[] = $row;
}

$stmt->close();
$conn->close();

http_response_code(200);
echo json_encode($ledger);
