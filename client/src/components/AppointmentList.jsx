import { useEffect, useState } from "react"
import { getAllAppointments } from "../data/appointmentData"



export const AppointmentList = () => {

    const [allAppointments, setAllAppointments] = useState([])


    const getAndResetAllAppointments = () => {
        getAllAppointments().then(appointmentsArray => {
            setAllAppointments(appointmentsArray)
        })
    }

    useEffect(() => {
        getAndResetAllAppointments()
    }, [])

 

    return (
        <>
        <h1>Appointments</h1>
        <div>     
            {allAppointments.map((appt) => (
                <div key={appt.id} className="logo">

                    <h2>Customer:</h2>
                    <h3>{appt.customer.name}</h3>
                    <h2>Stylist:</h2>
                    <h3>{appt.stylist.name}</h3>
                    <h2>Time:</h2>
                    <h3>{new Date(appt.time).toLocaleDateString()}</h3> 
                    {appt.services.map(s => <h3 key = {s.id}>{s.type}</h3>)}
                    <button className="btn-primary">Details</button>       
                </div>
            ))}
        </div>
        </>
    )
}