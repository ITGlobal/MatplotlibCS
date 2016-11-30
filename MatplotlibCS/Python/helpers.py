from datetime import datetime


def if_string_convert_to_datetime(x):
    '''
    Checks if x is a string, then trying to convert it to datetime and return the result.
    If x is not a string, just returns the x itself
    :param self:
    :return:
    '''

    if isinstance(x, list):
        X = []
        for _x in x:
            X.append(if_string_convert_to_datetime(_x))
        return X

    if isinstance(x, str):
        # return datetime.strptime(x[0:19] + x[27:30] + x[31:33], '%Y-%m-%dT%H:%M:%S%z')
        # .net yyyy-MM-ddTHH:mm:ss,fff,zzz
        return datetime.strptime(x, '%Y-%m-%dT%H:%M:%S,%f')
    return x
