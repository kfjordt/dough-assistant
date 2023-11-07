export class ApiService {
    static sendPostRequest(payload: string) {
        const requestPayload = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify({ message: payload })
        }

        return fetch("https://localhost:5001/api/expenses", requestPayload)
    }
}