import { useEffect, useState } from "react"
import { getAllAppointments } from "../data/appointmentData"
import { useNavigate } from "react-router-dom"



export const AppointmentList = () => {

    const [allAppointments, setAllAppointments] = useState([])
    const navigate = useNavigate()


    const getAndResetAllAppointments = () => {
        getAllAppointments().then(appointmentsArray => {
            setAllAppointments(appointmentsArray)
        })
    }

    useEffect(() => {
        getAndResetAllAppointments()
    }, [])

    const handleDetailsClick = (event) => {
        navigate(`/appointments/${event.target.value}`)
    } 

    return (
        <>
        <h1>Appointments</h1>
        <div>     
            {allAppointments.map((appt) => (
                <div key={appt.id} className="logo">                  
                    <h2>Time:</h2>
                    <h3>{new Date(appt.time).toLocaleDateString()}</h3> 
                    <h2>Services:</h2>
                    {appt.services.map(s => <h3 key = {s.id}>{s.type}</h3>)}
                    <button className="btn-primary" value={appt.id} onClick={handleDetailsClick}
                    >Details</button>       
                </div>
            ))}
        </div>
        </>
    )
}