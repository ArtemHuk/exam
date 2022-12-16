import Row from 'react-bootstrap/Row';
import Col from 'react-bootstrap/Col'
import UserTable from './UserTable';
import InterviewTable from './InterviewTable';



const Menu = () => {
    
    return (
        <>
            <Row>
                <Col><UserTable path={"candidates"}/></Col>
                <Col><UserTable path={"interviewers"}/></Col>
                <Col><InterviewTable/></Col>
            </Row>
        </>
    )

}

export default Menu;