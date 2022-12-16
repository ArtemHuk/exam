import Table from 'react-bootstrap/Table';
import { useState } from 'react';
import { useEffect } from 'react';
import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col';
import axios from "axios"
import {Button,Form } from "react-bootstrap";
import InterviewModal from './InterviewModal';



const InterviewTable = () => {

    const [filterDate,setFilterDate] = useState("");
    const [interviews, setInterviews] = useState(null);
    
    async function fetchData() {
        await axios.get('https://localhost:7050/api/interviews')
      .then(async (response) => setInterviews( await response.data));
    };

    useEffect(()  =>  {
    
    fetchData();

    },[]);

    const getFiltered = async ()=>{
        await axios.get('https://localhost:7050/api/interviews/'+filterDate)
      .then(async (response) => {
        const res = await response;    
        setInterviews( res.data)
        
        
    }).catch(error=> setInterviews(null));
    }
  
    const mapExperienceLevel = (level)=>{
        
        switch(level){
            case 0: {
                return "Intern";
            }
            case 1: {
                return "Junior";
            }
            case 2: {
                return "Middle";
            }
            case 3: {
                return "Senior";
            }
        }
    }


    const createInterview = (interview) => {
        
        return interview?.map((t, i) => (
            <tr>
                <td>
                    {i + 1}
                </td>
                <td>
                    {t.id}
                </td>
                <td>
                    {t.creationDate}
                </td>
                <td>
                    {t.candidateId}
                </td>
                <td>
                    {t.interviewerId}
                </td>
                <td>
                    {t.interviewDate}
                </td>
            </tr>
        ) ) ;
    }
    return(
        <>     
        <Row>
            <Col>
            <Form>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Filter by date</Form.Label>
                    <Form.Control 
                    type="date" 
                    placeholder="Enter interview date" 
                    onChange={(e) => setFilterDate(e.target.value)}
                    />
                </Form.Group>
                <Button onClick={()=> getFiltered()}>Apply</Button>
                <Button onClick={()=> fetchData()}>Unapply</Button>
                <InterviewModal/>
            </Form>
            </Col>
            <Col>
            </Col>
        </Row>
        <Row>
        <Table striped bordered hover>
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Id</th>
                        <th>Creation Date</th>
                        <th>Candidate Id</th>
                        <th>Interviewer Id</th>
                        <th>Interview Date</th>
                    </tr>
                </thead>
                <tbody>
                    {createInterview(interviews)}
                </tbody>
            </Table> 
        </Row>
               
        </>
    );
}

export default InterviewTable;