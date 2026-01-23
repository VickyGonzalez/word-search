import { useState } from "react";
import { searchWords } from "../services/wordSearchApi";
import MatrixGrid from "./MatrixGrid";
import FoundWords from "./FoundWords";

function WordForm() {
  const [letters, setLetters] = useState("");
  const [words, setWords] = useState("");
  const [matrix, setMatrix] = useState([]);
  const [found, setFound] = useState([]);
  const [error, setError] = useState(null);
  const [loading, setLoading] = useState(false);

  const handleLettersChange = (value) => {
    setLetters(value);
    setFound([]);
    setError(null);

    const newMatrix = value
      .split("\n")
      .map(line => line.replace(/\s/g, "").split(""))
      .filter(row => row.length > 0);

    setMatrix(newMatrix);
  };

  const handleSearch = async (e) => {
    e.preventDefault();
    setError(null);
    setLoading(true);

    try {
      const rows = letters
        .split("\n")
        .map(r => r.replace(/\s/g, "").trim())
        .filter(Boolean);

      const wordList = words
        .split(",")
        .map(w => w.trim())
        .filter(Boolean);

      const data = await searchWords({
        matrix: rows,   
        words: wordList
      });

      setFound(data.foundWords);
    } catch (err) {
      setError(
        err.response?.data?.message ||
        "Unexpected error while searching words."
      );
    } finally {
      setLoading(false);
    }
  };

  const highlightedPositions = found.flatMap(f => f.positions ?? []);

  return (
    <div style={{ textAlign: "center" }}>
      <form
        onSubmit={handleSearch}
        style={{
          display: "flex",
          flexDirection: "column",
          alignItems: "center",
          gap: "1rem"
        }}
      >
        <div style={{ width: "100%", maxWidth: 260, textAlign: "left" }}>
          <label>Letter Grid</label>
          <textarea
            rows={6}
            value={letters}
            onChange={(e) => handleLettersChange(e.target.value)}
            placeholder={`c h i l l
w i n d`}
            style={{ width: "100%" }}
          />
        </div>

        <div style={{ width: "100%", maxWidth: 260, textAlign: "left" }}>
          <label>Words to search</label>
          <input
            type="text"
            value={words}
            onChange={(e) => setWords(e.target.value)}
            placeholder="chill, wind"
            style={{ width: "100%" }}
          />
        </div>

        <button type="submit" disabled={loading}>
          {loading ? "Searching..." : "Search"}
        </button>
      </form>

      {error && (
        <p style={{ color: "red", marginTop: "1rem" }}>
          {error}
        </p>
      )}

      {matrix.length > 0 && (
        <MatrixGrid
          matrix={matrix}
          highlighted={highlightedPositions}
        />
      )}

      {found.length > 0 && (
        <FoundWords words={found} />
      )}
    </div>
  );
}

export default WordForm;
