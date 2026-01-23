function FoundWords({ words }) {
  return (
    <div style={{ marginTop: "1.5rem" }}>
      <h3>Found words</h3>
      <ul style={{ listStyle: "none", paddingLeft: 0 }}>
        {words.map(w => (
          <li key={w.word}>
            <strong>✔ {w.word}</strong>
          </li>
        ))}
      </ul>
    </div>
  );
}

export default FoundWords;
