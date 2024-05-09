const _apiUrl = "/api/appointments";



export const getAllAppointments = () => {
    return fetch(_apiUrl).then((r) => r.json());
}
