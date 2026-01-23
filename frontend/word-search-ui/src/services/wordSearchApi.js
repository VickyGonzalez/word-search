import apiClient from "./apiClient";

export async function searchWords({ matrix, words }) {
  const res = await apiClient
        .post("/WordSearch", { matrix, words });
    return res.data;
}
