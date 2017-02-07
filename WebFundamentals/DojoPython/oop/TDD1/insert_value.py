def insert_val_at(index, my_list, value):
    # delete the pass below and write the implementation here
    if index >= len(my_list):
        return False
    my_list.insert(index, value)
    return my_list
