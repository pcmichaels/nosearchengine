import React, { Component } from 'react';
import { Collapse, Container, Navbar, NavbarBrand, NavbarToggler, NavItem, NavLink } from 'reactstrap';
import { Link } from 'react-router-dom';
import { LoginMenu } from './api-authorization/LoginMenu';
import './NavMenu.css';


interface INavMenuProps {

}

interface IState {
  collapsed: boolean
}

export class NavMenu extends Component<INavMenuProps, IState> {
  static displayName = NavMenu.name;

  constructor (props: INavMenuProps) {
    super(props);

    this.toggleNavbar = this.toggleNavbar.bind(this);
    this.state = {
      collapsed: true
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
                <NavItem className="custom-nav">
                  <NavLink tag={Link} className="text-dark" to="/approval">Approval</NavLink>
                </NavItem>

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
