import VocalcomLogo from "../assets/logo-vocalcom.svg"; // logo con fondo blanco
//import WordSearchImage from "./assets/wordsearch.png"; // imagen del juego

function Home({ onStart }) {
  return (
    <div style={{
      backgroundColor: "#1e1e1e",
      minHeight: "100vh",
      display: "flex",
      flexDirection: "column",
      alignItems: "center",
      justifyContent: "center"
    }}>
      <h1 style={{ fontSize: "36px", marginBottom: "20px" }}>Word Search</h1>
      <img src={VocalcomLogo} alt="Vocalcom Logo" style={{ width: "150px", marginBottom: "20px" }} />
      <button 
        onClick={onStart}
        style={{
          marginTop: "30px",
          padding: "15px 50px",
          fontSize: "18px",
          borderRadius: "10px",
          cursor: "pointer",
          backgroundColor: "#ff5a5f",
          color: "white",
          border: "none",
          boxShadow: "0 4px 8px rgba(0,0,0,0.2)"
        }}
      >
        Start
      </button>
    </div>
  );
}

export default Home;
