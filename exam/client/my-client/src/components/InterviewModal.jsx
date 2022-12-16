import React, { useState } from 'react';
import { useEffect } from 'react';
import axios from "axios"

import { Modal,Button,Form } from "react-bootstrap";

const InterviewModal = () => {
    const [show, setShow] = useState(false);

    const handleClose = () => setShow(false);
    const handleShow = () => setShow(true);

    const [candidateId, setCandidateId] = useState(0);
    const [interviewerId, setInterviewerId] = useState(0);
    const [interviewDate, setInterviewDate] = useState("");
  
    const addInterview = async () => {
        await axios.post('https://localhost:7050/api/interviews',{id:0, 
        creationDate: "2022-12-20",
        candidateId,
        interviewerId, 
        interviewDate })
      .then(async (response) => console.log(response));
    }

    return (
      <>
        <Button variant="primary" onClick={handleShow}>
          Add interview
        </Button> {' '}
  
        <Modal show={show} onHide={handleClose}>
          <Modal.Header closeButton>
            <Modal.Title>Add interview</Modal.Title>
          </Modal.Header>
          <Modal.Body>
          <Form>
                <Form.Group className="mb-3" controlId="formBasicEmail">
                    <Form.Label>Candidate id</Form.Label>
                    <Form.Control 
                    type="number" 
                    
                    onChange={(e) => setCandidateId(e.target.value)}
                    value={candidateId} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicName">
                    <Form.Label>Interviewer id</Form.Label>
                    <Form.Control 
                    type="number" 
                    
                    onChange={(e) => setInterviewerId(e.target.value)}
                    value={interviewerId} />
                </Form.Group>

                <Form.Group className="mb-3" controlId="formBasicCity">
                    <Form.Label>Interview date</Form.Label>
                    <Form.Control 
                    type="date" 
                    onChange={(e) => setInterviewDate(e.target.value)}
                    value={interviewDate} />
                </Form.Group>         
            </Form>
          </Modal.Body>
          <Modal.Footer>
            <Button variant="secondary" onClick={handleClose}>
              Close
            </Button>
            <Button variant="primary" onClick={()=>addInterview()}>
              Save Changes
            </Button>
          </Modal.Footer>
        </Modal>
      </>
    );
}

export default InterviewModal;