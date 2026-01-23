import React, { useState } from "react";
import Home from "./components/Home";
import Game from "./components/Game";

function App() {
  const [started, setStarted] = useState(false);

  return (
    <div>
      {started ? (
        <Game />
      ) : (
        <Home onStart={() => setStarted(true)} />
      )}
    </div>
  );
}

export default App;
