import moment from 'moment';

window.formatDate = function (value, format) {
    if (value) {
        format = format || 'MM/DD/YYYY';
        return moment(String(value)).format(format);
    }
  };