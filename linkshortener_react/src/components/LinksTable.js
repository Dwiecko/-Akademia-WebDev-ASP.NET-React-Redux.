import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
//import { CFG_HTTP } from '../cfg/cfg_http';
//import { Link } from 'react-router';
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow
} from 'material-ui/Table';

import LinkInterface from '../interfaces/link';

const LinksTable = (props) => {
  //let address = {CFG_HTTP.URL_BASE}{CFG_HTTP.URL_LINKS}+"/";
  let links = props.links.map((link) => {
    return (
      <TableRow>
        <TableCell>{link.url}</TableCell>
        <TableCell>{link.hash}</TableCell>
      </TableRow>
    );
  });

  return (
    <Grid className="linksTable" container>
      <Grid item xs={12} md={8}>    
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>URL</TableCell>
              <TableCell>Hash</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {links}
          </TableBody>
        </Table>
      </Grid>
    </Grid>
  );
};

LinksTable.propTypes = {
  links: PropTypes.arrayOf(LinkInterface)
};

export default LinksTable;
