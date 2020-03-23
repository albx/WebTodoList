class ListItemViewModel {
    id;
    text;
    isDone;

    static map(id, text, isDone) {
        let viewModel = new ListItemViewModel();
        viewModel.id = id;
        viewModel.text = text;
        viewModel.isDone = isDone;

        return viewModel;
    }
}

export default ListItemViewModel;