const _apiUrl = "/api/stylists";



export const getAllStylists = () => {
    return fetch(_apiUrl).then((r) => r.json());
}

export const editStylistStatus = (stylistId) => {
    return fetch(`${_apiUrl}/${stylistId}/status`, {
        method: "PUT",
        headers: {
            "Content-Type": "application/json",
        },
        body: JSON.stringify(stylistId),
    }).then((res) => res.json())
}
