function MatrixGrid({ matrix, highlighted }) {
  const isHighlighted = (row, col) =>
    highlighted.some(p => p.row === row && p.col === col);

  return (
    <div style={{ display: "inline-block", marginTop: "1rem" }}>
      {matrix.map((row, r) => (
        <div key={r} style={{ display: "flex" }}>
          {row.map((char, c) => (
            <div
              key={c}
              style={{
                color: "black",
                width: 36,
                height: 36,
                borderRadius: 8,
                margin: 3,
                display: "flex",
                alignItems: "center",
                justifyContent: "center",
                fontWeight: "bold",
                fontSize: "1.1rem",
                backgroundColor: isHighlighted(r, c)
                  ? "#ffe066"
                  : "#f1f3f5",
                transition: "background-color 0.3s ease",
              }}
            >
              {char.toUpperCase()}
            </div>
          ))}
        </div>
      ))}
    </div>
  );
}

export default MatrixGrid;
