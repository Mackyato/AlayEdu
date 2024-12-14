<?php
require_once 'db.php';

// Check if 'UserID' is set in the GET request
if (!isset($_GET['UserID']) || empty($_GET['UserID'])) {
    http_response_code(400); // Bad Request
    echo json_encode(["error" => "Missing or invalid UserID", "debug" => $_GET]);
    exit;
}

$userId = $_GET['UserID'];

// Query to fetch ledger entries for the given UserID
$sql = "SELECT * FROM tblledger WHERE UserID = ?";
$stmt = $conn->prepare($sql);
$stmt->bind_param("i", $userId);
$stmt->execute();
$result = $stmt->get_result();

// Format data to match the JSON structure you want
$ledgerEntries = [];
while ($row = $result->fetch_assoc()) {
    $ledgerEntries[] = [
        "ID" => $row["ID"],
        "UserID" => $row["UserID"],
        "SchoolYear" => $row["SchoolYear"],
        "Term" => $row["Term"],
        "DatePaid" => $row["DatePaid"],
        "Particulars" => $row["Particulars"],
        "Credit" => $row["Credit"],
        "Balance" => $row["Balance"],
        "OldAccounts" => $row["OldAccounts"]
    ];
}

// Return the result as JSON
header('Content-Type: application/json');
echo json_encode($ledgerEntries);
?>
