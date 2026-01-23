import WordForm from "./WordForm";

function Game() {
  return (
    <div style={{
      backgroundColor: "#1e1e1e",
      color: "white",
      minHeight: "100vh",
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
      justifyContent: "center"
    }}>
      <h1 style={{ fontSize: "36px", marginBottom: "20px" }}>Word Search Game</h1>
      <WordForm />
    </div>
  );
}

export default Game;
