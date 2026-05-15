function startGame(){
    document.getElementById("menu").style.display = "none";
    document.querySelector(".game").style.display = "block";

}
const board = document.getElementById("board");
const statusText = document.getElementById("status");

let cells = [];
let currentPlayer = "X";
let gameActive = true;
/// πιθανοι σχεδιασμη νικης
const winPatterns = [
    [0,1,2],[3,4,5],[6,7,8],
    [0,3,6],[1,4,7],[2,5,8],
    [0,4,8],[2,4,6]
];

// Διμιουργια πινακα
for (let i = 0; i < 9; i++) {
    const cell = document.createElement("div");
    cell.classList.add("cell");
    cell.dataset.index = i;
    cell.addEventListener("click", handleClick);
    board.appendChild(cell);
    cells.push(cell);
}
//// Συνάρτηση που εκτελειτε οταν ο χρηστης πατηση το κουμπι 
function handleClick(e) {
    const cell = e.target;
    const index = cell.dataset.index;

    if (cell.textContent !== "" || !gameActive) return;

    cell.textContent = currentPlayer;
    cell.classList.add(currentPlayer.toLowerCase());

    if (checkWin()) {
        statusText.textContent = `Νίκησε ο ${currentPlayer}!`;
        gameActive = false;
        return;
    }

    if (cells.every(c => c.textContent !== "")) {
        statusText.textContent = "Ισοπαλία!";
        gameActive = false;
        return;
    }

    currentPlayer = currentPlayer === "X" ? "O" : "X";
    statusText.textContent = `Σειρά: ${currentPlayer}`;
}

/// Συναρτηση ελεγχου νικητη
function checkWin() {
    return winPatterns.some(pattern => {
        return pattern.every(i => {
            return cells[i].textContent === currentPlayer;
        });
    });
}
// συναρτηση για restart παιχνιδιου αφου τελιωσουν η players
function resetGame() {
    cells.forEach(cell => {
        cell.textContent = "";
        cell.classList.remove("x", "o");
    });
    currentPlayer = "X";
    gameActive = true;
    statusText.textContent = "Σειρά: X";
}