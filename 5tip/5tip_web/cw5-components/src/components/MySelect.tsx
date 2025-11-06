
type Props = {
    title: string;
    options: string[];
    handleOnChange: (value: string) => void;
}

const MySelect = (props: Props) => {
  return (
    <div>
        <label>{props.title}</label>
        <select onChange={(e) => props.handleOnChange(e.target.value)}>
            {props.options.map((option, index) => (
                <option key={index} value={option}>{option}</option>
            ))}
        </select>
    </div>
  )
}

export default MySelect