import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';

import store, { IStore } from '../State/Store';
import { connect } from 'react-redux';

interface INavMenuStateProps {
  userRating: number;
}

interface INavMenuOwnProps {

}

interface INavMenuDispatchProps {

}

type Props = INavMenuOwnProps & INavMenuStateProps & INavMenuDispatchProps;

interface IState {
  collapsed: boolean,
  isUserApprover: boolean
}

class NavMenu extends Component<Props, IState> {
  static displayName = NavMenu.name;

  constructor (props: Props) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true,
      isUserApprover: false
    };
  }

  toggleNavbar () {
    this.setState({
      collapsed: !this.state.collapsed
    });
  }

  render () {
    return (
      <header>
        <Navbar className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3" light>
          <Container>
            <NavbarBrand tag={Link} to="/">No Search</NavbarBrand>
            <NavbarToggler onClick={this.toggleNavbar} className="mr-2" />
            <Collapse className="d-sm-inline-flex flex-sm-row-reverse" isOpen={!this.state.collapsed} navbar>
              <ul className="navbar-nav flex-grow">
                <NavItem className="custom-nav">
                  <NavLink tag={Link} className="text-dark" to="/">Home</NavLink>
                </NavItem>
                <NavItem className="custom-nav">
                  <NavLink tag={Link} className="text-dark" to="/addSite">Add Site</NavLink>
                </NavItem>
                <NavItem className="custom-nav">
                  <NavLink tag={Link} className="text-dark" to="/mySites">My Sites</NavLink>
                </NavItem>
                { this.props.userRating >= 100 &&
                  <NavItem className="custom-nav">
                    <NavLink tag={Link} className="text-dark" to="/approval">Approval</NavLink>
                  </NavItem>
                }

                <LoginMenu>
                </LoginMenu>

              </ul>
            </Collapse>
          </Container>
        </Navbar>
      </header>
    );
  }
}

function mapStateToProps(state: IStore) {
  return {
    userRating: state.userRating
  };
}

export default connect(mapStateToProps)(NavMenu);



